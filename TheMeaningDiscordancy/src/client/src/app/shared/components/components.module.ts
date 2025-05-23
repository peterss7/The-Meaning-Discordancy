import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconButtonComponent } from './icon-button/icon-button.component';
import { ActionBarComponent } from './action-bar/action-bar.component';


@NgModule({
  declarations: [
    IconButtonComponent,
    ActionBarComponent
  ],
  imports: [
    CommonModule,
  ],
  exports:[
    IconButtonComponent,
    ActionBarComponent
  ]
})
export class ComponentsModule { }
