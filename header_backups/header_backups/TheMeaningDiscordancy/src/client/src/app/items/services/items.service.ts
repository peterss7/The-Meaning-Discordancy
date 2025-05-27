import { BehaviorSubject, Observable } from "rxjs";
import { Item } from "../models/item.model";
import { Injectable } from "@angular/core";
import { DiscordConstants } from "src/app/constants/discord-constants.contants";
import { ClientService } from "src/app/core/services/client.service";

@Injectable({
  providedIn: 'root'
})

export class ItemsService {

  private apiUrl: string = `${DiscordConstants.API_BASE_URL}items`;

  private itemsSubject = new BehaviorSubject<Item[]>([]);
  public items$ = this.itemsSubject.asObservable();

  constructor(private client: ClientService) { }

  upload(data: FormData): Observable<any> {
    return this.client.post(`${this.apiUrl}/create`, data);
  }

  update(data: FormData): Observable<any> {
    console.log(`Enter update Item service method.`);
    return this.client.put(`${this.apiUrl}/update`, data);
  }

  delete(id: number): Observable<any> {
    return this.client.delete(`${this.apiUrl}/delete/${id}`);
  }

  updateSelected(id: number, isSelected: boolean): void {
    const updated = this.itemsSubject.value.map(item =>
      item.itemId === id ? { ...item, isSelected } : item
    );
    this.itemsSubject.next(updated);
  }

  getSelected(): Item[] {
    return this.itemsSubject.value.filter(Item =>
      Item.isSelected
    );
  }

  refresh(): void {
    this.client.get<Item[]>(`${this.apiUrl}/get-all`)
      .subscribe(items => {
        this.setItems(items);
      });
  }

  setItems(items: Item[]): void {
    console.log(`setting items: ${items.length}`);
    this.itemsSubject.next(items);
  }
}