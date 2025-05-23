import { Injectable } from '@angular/core';
import { DiscordConstants } from 'src/app/constants/discord-constants.contants';
import { Observable, shareReplay, tap } from 'rxjs';
import { ConfigData } from 'src/app/core/models/config-data.model';
import { ClientService } from './client.service';

@Injectable({
  providedIn: 'root'
})
export class ConfigService {

  private apiUrl: string = `${DiscordConstants.API_BASE_URL}config/`;
  private _config: ConfigData = new ConfigData();

  constructor(private client: ClientService) { }

  loadConfig(): Observable<ConfigData> {
    return this.client.get<{assetsFolder: string}>(`${this.apiUrl}get`).pipe(
      tap(config => this._config = config),
      shareReplay(1)
    );
  }

  get config(): ConfigData {
    return this._config;
  }
}
