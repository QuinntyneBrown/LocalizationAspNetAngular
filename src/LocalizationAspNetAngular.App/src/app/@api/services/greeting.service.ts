import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';
import { BASE_URL } from '@core';

@Injectable({
  providedIn: 'root'
})
export class GreetingService {

  constructor(
    @Inject(BASE_URL) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  public get(name: string): Observable<string> {
    return this._client.get<{ greeting: string }>(`${this._baseUrl}api/greeting?name=${name}`)
    .pipe(
      map(response => response.greeting)
    )
  }
}
