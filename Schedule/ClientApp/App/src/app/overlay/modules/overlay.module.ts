import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OverlayComponent } from '../components/overlay.component';
import {MatProgressBarModule} from "@angular/material/progress-bar";
import {OverlayService} from "../services/overlay.service";



@NgModule({
  declarations: [
    OverlayComponent
  ],
  exports: [
    OverlayComponent
  ],
  imports: [
    CommonModule,
    MatProgressBarModule
  ],
  providers: [
    OverlayService
  ]
})
export class OverlayModule { }
