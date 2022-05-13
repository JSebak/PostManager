import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  user: any;

  ngOnInit(){
    this.getUser();
  }
  guest()
  {
    this.user = "guest";
  }
  getUser(){
    let user = sessionStorage.getItem("user")?? null
    user == null ? this.user = null : this.user = JSON.parse(user)
    
  }
}
