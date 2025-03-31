import { Component, OnInit } from '@angular/core';
import { Keyword } from '../../models/keyword.model';
import { CommonModule } from '@angular/common';
import { AddKeywordComponent } from "../../components/add-keyword/add-keyword.component";
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-dashboard',
  imports: [
    CommonModule,
    AddKeywordComponent
],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {

  showRefreshAllAlert: boolean = false;
  refreshText = "";
  keywords: Keyword[] = [
    // { keyword: 'land registry searches', rank: 4, dateUpdated: new Date() },
    // { keyword: 'land registry searches by address', rank: 7, dateUpdated: new Date() },
    // { keyword: 'land registry title deeds', rank: 3, dateUpdated: new Date() },
  ]

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.loadKeywords();
  };

  loadKeywords() {  
    this.apiService.getKeywords().subscribe(
      (keywords: Keyword[]) => {  
        this.keywords = keywords.map(keyword => ({
          ...keyword,
          dateUpdated: new Date(keyword.dateUpdated) // Ensure dateUpdated is a Date object
        }));
      })
  }

  keywordAdded(keyword: string) {
    
    this.apiService.addKeyword(keyword).subscribe(
      response => {
        this.loadKeywords(); 
      });
  }

  refreshAll() {
    this.showRefreshAllAlert = true;
    this.refreshText = "refreshing ...";
    
    this.apiService.refreshAllKeywordRankings().subscribe(
      response => {
        
        this.loadKeywords(); 
        this.refreshText = "refreshed...";
        
        setTimeout(() => {
          this.showRefreshAllAlert = false;
        }, 1000);
    
      }
    );
  }
}
