import { Component } from '@angular/core';
import { ItemsService } from '../../services/items.service';
import { Subscription } from 'rxjs';
import { Item } from '../../models/item.model';
import { StylesService } from 'src/app/shared/services/styles.service';

@Component({
  selector: 'discord-item-table',
  templateUrl: './item-table.component.html',
  styleUrls: ['./item-table.component.scss']
})
export class ItemTableComponent {
  private itemsSub: Subscription | null = null;

  items: Item[] = [];
  gridSize: number = 0;
  gridArray: any = [];
  gridRows: number = 1;
  gridColumns: number = 1;

  constructor(private itemsService: ItemsService,
    private stylesService: StylesService
  ) { }

  ngOnInit() {
    this.itemsService.refresh();
    this.setGridDimensions();
  }

  getImageStyle(name: string): { [key: string]: string } {
    return this.stylesService.getImageStyle(name);
  }

  setGridDimensions(): void {
    this.itemsSub = this.itemsService.items$.subscribe(items => {
      this.items = items;
      this.gridArray = Array.from({ length: items.length });
      this.gridRows = Math.ceil(Math.sqrt(items.length / 3));
      this.gridColumns = 3 * this.gridRows;
      console.log(`gridSize: ${this.gridSize}, gridSize: ${this.gridArray}`);
      console.log(`items num in initTable: ${items.length}`);
    });
  }

  ngOnDestroy() {
    this.itemsSub?.unsubscribe();
  }
}
