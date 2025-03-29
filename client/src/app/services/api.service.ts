import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Configuration } from '../models/configuration.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  
  constructor(private http: HttpClient) {}

  fetchConfiguration() {
    return this.http.get<Configuration>('configuration');
  }

  updateConfiguration(domain: string) {
    return this.http.post('configuration', { domain });
  }

  addKeyword(keyword: string) {
    return this.http.post('keywords', { keyword});
  }
}
