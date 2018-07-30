import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BookComponent } from './book.component';
import { PostComponent} from './post/post.component';
import { PhuongComponent } from './phuong/phuong.component';
import { DungComponent } from './dung/dung.component';
import { HeaderComponent } from './header/header.component';




@NgModule({
  imports:      [ BrowserModule ],
    declarations: [AppComponent,
        BookComponent,
        ,
        
        HeaderComponent,
        PostComponent,
        
        
        
        PhuongComponent,
        
        
        
        DungComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }
