import { Component, OnDestroy, OnInit } from '@angular/core';
import { ControllerFunction, RequestMethodType, ServerService } from "../../services/server/server.service";
import { Product } from "../../models/DatabaseObjects";
import { Subscription } from 'rxjs';
import { TranslationService } from "../../services/translation/translation.service";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit, OnDestroy {

  products: Product[] = [];
  private languageChangeSubscription!: Subscription;
  constructor(private serverService: ServerService, private translationService: TranslationService) {}

  async ngOnInit() {
    this.products = await this.serverService.ExecuteServerFunction(ControllerFunction.GetProducts, { Language: "sl" }, RequestMethodType.POST);
    this.languageChangeSubscription = this.translationService.languageChange$.subscribe(async (lang: string) => {
      this.products = await this.serverService.ExecuteServerFunction(ControllerFunction.GetProducts, { Language: lang }, RequestMethodType.POST);
    });
  }

  ngOnDestroy() {
    if (this.languageChangeSubscription) {
      this.languageChangeSubscription.unsubscribe();
    }
  }

  async testMethod() {
    const response = await this.serverService.ExecuteServerFunction(ControllerFunction.AddUser, {}, RequestMethodType.POST);
    console.log(response);
  }

}
