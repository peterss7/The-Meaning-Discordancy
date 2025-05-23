import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfigService } from './services/config.service';
import { ClientService } from './services/client.service';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    
  ],
  providers:[
    ConfigService,
    ClientService,    
  ]
})
export class CoreModule { }
