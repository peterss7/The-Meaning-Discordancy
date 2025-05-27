// Copyright © 2025 Steven Peterson
// All rights reserved.  
// 
// No part of this code may be copied, modified, distributed, or used  
// without explicit written permission from the author.
// 
// For licensing inquiries or collaboration opportunities:
// 
// GitHub: https://github.com/peterss7  
// LinkedIn: https://www.linkedin.com/in/steven-peterson7405926/

import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ItemsService } from './services/items.service';
import { SharedModule } from '../shared/shared.module';
import { ItemsComponent } from './items.component';
import { ComponentsModule } from './components/components.module';
import { ItemTableModule } from "./components/item-table/item-table.module";

@NgModule({
  declarations: [
    ItemsComponent,    
  ],
  imports: [
    CommonModule,
    SharedModule,
    ComponentsModule,
    ItemTableModule
],
  providers:[
    ItemsService,
  ],
  exports:[
  ]
})
export class ItemsModule { }
