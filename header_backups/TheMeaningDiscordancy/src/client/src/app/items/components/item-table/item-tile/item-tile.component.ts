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

import { Component, Input } from '@angular/core';
import { DiscordConstants } from 'src/app/constants/discord-constants.contants';
import { Item } from 'src/app/items/models/item.model';
import { ItemsService } from 'src/app/items/services/items.service';

@Component({
  selector: 'discord-item-tile',
  templateUrl: './item-tile.component.html',
  styleUrls: ['./item-tile.component.scss']
})
export class ItemTileComponent {
  @Input() item: Item = new Item();

  constructor(private itemsService: ItemsService) { }

  getImageUrl(): string {
    return `${DiscordConstants.API_BASE_URL}items/${this.item.imageName}`;
  }

  onCheckItem(id: number, isSelected: boolean): void {
    this.itemsService.updateSelected(id, isSelected);
  }
}
