import { Component, OnDestroy, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationEnd, Router, RouterModule } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { Website } from '../../models/website.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-header',
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit, OnDestroy {
  
  domain: string = '';
  private routerEventsSubscription: Subscription | undefined;
  
  constructor(private apiService: ApiService, private router: Router) {
    
  }
  
  ngOnInit(): void {
    
    this.routerEventsSubscription = this.router.events.subscribe((event: any) => {
      
      if (event instanceof NavigationEnd) {
        this.apiService.getWebsite().subscribe((response: Website) => {
          this.domain = response.domain;
        }, (error: any) => {
          console.log("Domain not configured yet");
        })
      }
    });
  };

  ngOnDestroy() {
    if (this.routerEventsSubscription) {
      this.routerEventsSubscription.unsubscribe();
    }
  }
  
}
