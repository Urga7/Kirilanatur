import { Component } from '@angular/core';
import { ControllerFunction, RequestMethodType, ServerService } from "../../services/server/server.service";

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.css'
})
export class AdminComponent {
  constructor(private serverService: ServerService) {}

  async testMethod() {

  }

}
