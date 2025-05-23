import { Component, Input } from '@angular/core';

@Component({
  selector: 'discord-action-header',
  templateUrl: './action-header.component.html',
  styleUrls: ['./action-header.component.scss']
})
export class ActionHeaderComponent {
  @Input() title: string = "";
  @Input() subtitle: string = "";
}
