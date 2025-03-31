import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Website } from '../models/website.model';
import { Keyword } from '../models/keyword.model';

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
    return this.http.post('keywords', { keyword });
  }

  getKeywords() {
    return this.http.get<Keyword[]>('keywords');
  }

  refreshAllKeywordRankings() {
    return this.http.get('keywords/refresh-all');
  }

  deleteKeyword(id: number) {
    return this.http.delete(`keywords/${id}`);
  }

  refreshKeyword(id: number) {
    return this.http.get(`keywords/refresh/${id}`);
  }
}
