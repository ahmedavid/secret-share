import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of,map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Secret } from '../_models/interfaces';

@Injectable({
  providedIn: 'root'
})
export class SecretService {
  baseUrl = environment.apiUrl

  constructor(private http: HttpClient) { }

  createSecret(secret: Secret) {
    return this.http.post<Secret>(this.baseUrl + 'secret',secret)
  }

  getSecret(accessId: string) {
    return this.http.get<Secret>(this.baseUrl+'secret/'+accessId)
  }
}
