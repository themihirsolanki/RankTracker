import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../../services/api.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

@Component({
  selector: 'app-setup-keywords',
  imports: [
      CommonModule, 
      FormsModule, 
      RouterModule
    ],
  templateUrl: './setup-keywords.component.html',
  styleUrl: './setup-keywords.component.css',
  standalone: true
})
export class SetupKeywordsComponent {

  keywords: string = '';

  constructor(private router: Router,
    private apiService: ApiService
  ) {}
  
  onSubmit() {
    if (this.keywords.trim() === '') {
      alert('Please add at least one keyword.');
      return;
    }

    var keywordsArray = this.keywords.split('\n').map(keyword => keyword.trim()).filter(keyword => keyword !== '');;
    if (keywordsArray.length === 0) {
      alert('Please add at least one keyword.');
      return;
    }

    this.apiService.addKeywords(keywordsArray).subscribe(
      (response) => {
        this.router.navigate(['/']);
      })

  }

}
