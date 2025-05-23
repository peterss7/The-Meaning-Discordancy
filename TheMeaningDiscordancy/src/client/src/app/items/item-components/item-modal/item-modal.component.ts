import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'discord-item-modal',
  templateUrl: './item-modal.component.html',
  styleUrls: ['./item-modal.component.scss'],
  
})
export class ItemModalComponent implements OnInit {  
  
  public name: string = '';

  ngOnInit(){
    console.log('TTTTT');
  }
}
