import { Component, OnInit } from '@angular/core';
import { KeywordRank } from '../../models/keyword-rank.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  
  keywordRanks: KeywordRank[] = [
    { keyword: 'land registry searches', position: 4, dateUpdated: new Date() },
    { keyword: 'land registry searches by address', position: 7, dateUpdated: new Date() },
    { keyword: 'land registry title deeds', position: 3, dateUpdated: new Date() },
  ]

  constructor() { }

  ngOnInit(): void {
    console.log("DashboardComponent initialized");    
  }
}
