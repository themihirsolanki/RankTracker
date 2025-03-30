import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Website } from '../models/website.model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  
  constructor(private http: HttpClient) {}

  getWebsite() {
    return this.http.get<Website>('websites');
  }

  updateWebsite(domain: string) {
    return this.http.post('websites', { domain });
  }

  addKeyword(keyword: string) {
    return this.http.post('keywords', { keyword});
  }
}
