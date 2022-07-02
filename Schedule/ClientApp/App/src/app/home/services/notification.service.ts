import { Injectable } from '@angular/core';
import {ToastrService} from "ngx-toastr";

@Injectable()
export class ToastrNotificationService {
  constructor(private toastrService: ToastrService) { }

  showErrorMessage(message: string) {
      this.toastrService.error(message);
  }

  showSuccessMessage(message: string) {
      this.toastrService.success(message);
  }

  showInfoMessage(message: string) {
      this.toastrService.info(message);
  }

  showWarningMessage(message: string) {
      this.toastrService.warning(message);
  }
}
