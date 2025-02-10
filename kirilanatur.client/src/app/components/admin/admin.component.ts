import { Component } from '@angular/core';
import { ControllerFunction, ServerService } from "../../services/server.service";

@Component({
    selector: 'app-admin',
    templateUrl: './admin.component.html',
    styleUrl: './admin.component.css',
    standalone: true
})
export class AdminComponent {
  constructor(private serverService: ServerService) {}

  async testMethod() {
    const response: any = await this.serverService.ExecuteServerFunction(ControllerFunction.GetUsers);
    console.log(response);
  }

}
