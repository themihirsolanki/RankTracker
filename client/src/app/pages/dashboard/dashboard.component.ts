import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent implements OnInit {
  constructor() { }

  ngOnInit(): void {
    console.log("DashboardComponent initialized");    
  }
}
