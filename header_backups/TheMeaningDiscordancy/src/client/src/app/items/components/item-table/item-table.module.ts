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
import { ItemTileComponent } from './item-tile/item-tile.component';
import { ItemTableComponent } from './item-table.component';

@NgModule({
  declarations: [
    ItemTileComponent,
    ItemTableComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    ItemTableComponent
  ]
})
export class ItemTableModule { }
