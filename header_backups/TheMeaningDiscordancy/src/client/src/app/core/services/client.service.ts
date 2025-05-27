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

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NormalizeUrlPipe } from 'src/app/shared/pipes/normalize-url.pipe';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(
    private http: HttpClient,
    private urlPipe: NormalizeUrlPipe
  ) { }

  get<T>(url: string): Observable<T> {
    const apiUrl: string = this.urlPipe.transform(url);
    console.log(`sending to api, url: ${apiUrl}`);
    var result = this.http.get<T>(apiUrl);
    return result;
  }

  post(url: string, body: any): Observable<any> {
    const apiUrl: string = this.urlPipe.transform(url);
    console.log(`sending to api, url: ${apiUrl}`);
    return this.http.post(apiUrl, body);
  }

  put(url: string, body: any): Observable<any> {
    const apiUrl: string = this.urlPipe.transform(url);
    console.log(`sending to api, url: ${apiUrl}`);
    return this.http.put(apiUrl, body);
  }

  delete(url: string): Observable<any> {
    const apiUrl: string = this.urlPipe.transform(url);
    console.log(`sending to api, url: ${apiUrl}`);
    return this.http.delete(apiUrl);
  }
}
