import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-setup',
  imports: [
    CommonModule, 
    FormsModule,
    RouterModule
  ],
  templateUrl: './setup.component.html',
  styleUrl: './setup.component.css'
})
export class SetupComponent {
  domain: string = '';

  constructor(private router: Router,
    private apiService: ApiService
  ) {}

  onSubmit() {
    if (this.domain.trim() === '') {
      alert('Domain cannot be empty.');
      return;
    }
    this.apiService.updateConfiguration(this.domain).subscribe(
      (response) => {
        this.router.navigate(['/']);
      })
  }
}
