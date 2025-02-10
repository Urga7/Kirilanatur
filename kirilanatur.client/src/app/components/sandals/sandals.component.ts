import { Component, OnDestroy, OnInit } from '@angular/core';
import { Product } from "../../models/database-objects";
import { Subscription } from 'rxjs';
import { ControllerFunction, RequestMethodType, ServerService } from "../../services/server/server.service";
import { TranslationService } from "../../services/translation/translation.service";
import { ShoppingCartService } from "../../services/shopping-cart/shopping-cart.service";
import { ChosenVariationOption } from "../../models/shopping-cart";
import { NgOptimizedImage } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

@Component({
    selector: 'app-sandals',
    templateUrl: './sandals.component.html',
    styleUrl: './sandals.component.css',
    standalone: true,
    imports: [NgOptimizedImage, ReactiveFormsModule]
})
export class SandalsComponent implements OnInit, OnDestroy {

  products: Product[] = [];
  selectedOptions: { [productId: string]: ChosenVariationOption[] } = {};
  private languageChangeSubscription!: Subscription;

  constructor(
    private serverService: ServerService,
    private translationService: TranslationService,
    public shoppingCartService: ShoppingCartService
  ) {}

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

}
