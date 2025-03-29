import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-add-keyword',
  imports: [
    CommonModule,
    FormsModule],
  templateUrl: './add-keyword.component.html',
  styleUrl: './add-keyword.component.css'
})
export class AddKeywordComponent {
  keyword: string = '';
  
  constructor(private apiService: ApiService) {
  }

  addKeyword() {
    this.apiService.addKeyword(this.keyword).subscribe(
      response => {
        console.log('Keyword added successfully:', response);
        this.keyword = '';
      });
  }
}
