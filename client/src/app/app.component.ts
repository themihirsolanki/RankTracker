import { Component } from '@angular/core';
import { GuardsCheckEnd, GuardsCheckStart, NavigationCancel, Router, RouterOutlet } from '@angular/router';
import { OnInit } from '@angular/core';
import { ApiService } from './services/api.service';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from "./components/header/header.component";

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    CommonModule,
    HeaderComponent
],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  loading: boolean = true;
  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events.subscribe(event => {
      if (event instanceof GuardsCheckStart) {
        this.loading = true;
      }     
      if (event instanceof GuardsCheckEnd || event instanceof NavigationCancel) {
        this.loading = false;
      } 
    });
    
  }
}
