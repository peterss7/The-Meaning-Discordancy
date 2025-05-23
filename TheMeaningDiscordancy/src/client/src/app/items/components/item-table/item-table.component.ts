import { Component } from '@angular/core';
import { Item } from '../../models/item.model';
import { ItemsService } from '../../services/items.service';
import { StylesService } from 'src/app/shared/services/styles.service';

@Component({
  selector: 'discord-item-table',
  templateUrl: './item-table.component.html',
  styleUrls: ['./item-table.component.scss']
})
export class ItemTableComponent {
  public items: Item[] = [];
  public gridSize: number = 0;
  public gridArray: any = [];
  public gridRows: number = 1;
  public gridColumns: number = 1;

  constructor(private itemsService: ItemsService,
    public stylesService: StylesService
  ) { }

  ngOnInit() {
    this.itemsService.refresh();
    this.itemsService.items$.subscribe(items => {
      this.items = items;
      this.gridArray = Array.from({ length: items.length });
      this.gridRows = Math.ceil(Math.sqrt(items.length / 3));
      this.gridColumns = 3 * this.gridRows;
      console.log(`gridSize: ${this.gridSize}, gridSize: ${this.gridArray}`);
      console.log(`items num in initTable: ${items.length}`);
    });
  }
}
