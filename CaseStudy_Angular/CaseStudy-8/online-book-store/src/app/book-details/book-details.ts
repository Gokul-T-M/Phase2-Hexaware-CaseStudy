import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Book } from '../book.model';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-book-details',
  imports:[CommonModule],
  standalone: true,
  templateUrl: './book-details.html'
})
export class BookDetailsComponent implements OnInit {
  book: Book | undefined;
  books: Book[] = [
    { id: 1, title: 'Angular Basics', author: 'Jane Coder', price: 299, description: 'Learn Angular from scratch.' },
    { id: 2, title: 'TypeScript Mastery', author: 'Max Programmer', price: 499, description: 'Deep dive into TypeScript and type safety...' },
    { id: 3, title: 'RxJS Deep Dive', author: 'Sam Stream', price: 399, description: 'Reactive programming with RxJS.' }
  ];

  constructor(private route: ActivatedRoute) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.book = this.books.find(b => b.id === id);
  }
}
