import { Routes } from '@angular/router';
import { Home } from './home/home';
import { BookList } from './book-list/book-list';
import { BookDetailsComponent } from './book-details/book-details';

export const routes: Routes = [

    {path:'',component:Home},
    {path:'books',component:BookList},
    {path:'books/:id',component:BookDetailsComponent}

];
