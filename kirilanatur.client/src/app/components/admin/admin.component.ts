import { Component, OnInit } from '@angular/core';
import { ControllerFunction, RequestMethodType, ServerService } from "../../services/server/server.service";
import { Product } from "../../services/user/user.service";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent implements OnInit {

  products: Product[] = [];

  constructor(private serverService: ServerService) {}

  async ngOnInit() {
    this.products = await this.serverService.ExecuteServerFunction(ControllerFunction.GetProducts, {}, RequestMethodType.GET);
  }

}
