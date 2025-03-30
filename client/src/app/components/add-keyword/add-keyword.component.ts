import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
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
  showAlert: boolean = false;

  @Output() keywordAdded = new EventEmitter<string>();
  
  constructor(private apiService: ApiService) { }

  addKeyword() {
    
    this.keywordAdded.emit(this.keyword.trim());
    this.keyword = '';
    this.showAlert = true;
    
    setTimeout(() => {
      this.showAlert = false;
    }, 2000);
  }
}
