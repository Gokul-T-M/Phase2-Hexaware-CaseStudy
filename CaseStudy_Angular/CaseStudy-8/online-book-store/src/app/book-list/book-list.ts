import { Component } from '@angular/core';
import { Book } from '../book.model';
import { RouterModule } from '@angular/router'; 
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-book-list',
  standalone:true,
  imports: [RouterModule,CommonModule],
  templateUrl: './book-list.html',
  styleUrl: './book-list.css'
})
export class BookList {

  books: Book[] = [

    { id: 1, title: 'Angular Basics', author: 'Jane Coder', price: 299, description: 'Learn Angular from scratch.'},
    { id: 2, title: 'TypeScript Mastery', author: 'Max Programmer', price: 499, description: 'Deep dive into TypeScript and type safety...' },
    { id: 3, title: 'RxJS Deep Dive', author: 'Sam Stream', price: 399, description: 'Reactive programming with RxJS.' }

  ]
}
