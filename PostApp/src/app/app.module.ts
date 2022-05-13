import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './Login/login.component';
import { DashboardComponent } from './Dashboard/dashboard.component';
import { PostListComponent } from './Post/Posts List/postlist.component';
import { NewPostComponent } from './Post/Create Post/newpost.component';
import { EditPostComponent } from './Post/Edit Post/editpost.component';
import { PostComponent } from './Post/post.component';
import { PostDetailsComponent } from './Post/View Post/postdetails.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    PostComponent,
    PostListComponent,
    PostDetailsComponent,
    NewPostComponent,
    DashboardComponent,
    EditPostComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
