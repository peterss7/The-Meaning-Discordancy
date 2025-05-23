import { Injectable } from '@angular/core';
import { ConfigService } from 'src/app/core/services/config.service';

@Injectable({
  providedIn: 'root'
})
export class ItemStylesService {

  private assetFolder: string = 'assets/';

  constructor(private configService: ConfigService) { }

  init(): void {
    const config = this.configService.config;
    this.assetFolder = config.assetsFolder !== '' ? config.assetsFolder : 'assets/';
  }

  getImageStyle(name: string): { [key: string]: string } {
    console.log(`img url: ${this.assetFolder}${name}.png`);
    return {
      backgroundImage: `url('${this.assetFolder}${name}.png')`,
      backgroundRepeat: 'no-repeat',
      backgroundSize: 'contain',
      backgroundPosition: 'center'
    };
  }
}