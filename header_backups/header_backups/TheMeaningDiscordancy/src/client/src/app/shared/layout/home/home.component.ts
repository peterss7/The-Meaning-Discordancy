import { Component } from '@angular/core';

@Component({
  selector: 'discord-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  public title: string = 'The Meaning Discordancy';
  public subtitle: string = 'Grand Semantic Battle';
}
