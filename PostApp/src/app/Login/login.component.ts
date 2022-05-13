import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../Services/User/user.services';

@Component({
  selector: 'login-component',
  templateUrl: './login.component.html',
//   styleUrls: ['./post.component.css']
})
export class LoginComponent {
  title = 'PostApp';
  valid!: boolean;
  loginForm!: FormGroup;
  @Output() login = new EventEmitter<boolean>();
  @Output() guestLogin = new EventEmitter<string>();
 
  constructor(private userService: UserService ) {

  }
  ngOnInit(){
      this.loginForm = new FormGroup({
          username: new FormControl('',[Validators.required,Validators.minLength(4), Validators.maxLength(20)]),
          password: new FormControl('',[Validators.required, Validators.minLength(6), Validators.maxLength(20)])
      });
      this.loginForm.valueChanges.subscribe(val => {
          setTimeout(()=>{
            if(this.loginForm.valid){
                this.valid = true;
            } else {
                this.valid = false;
            }
          }, 1000);
      })
  }
  guest()
  {
    this.guestLogin.emit("guest")
  }
  onSubmit(){
    let username = this.loginForm.controls["username"].value
    let password = this.loginForm.controls["password"].value
    
      if(this.loginForm.valid){
        this.userService.login(username,password).subscribe(res =>{
          sessionStorage.setItem("user",JSON.stringify(res.result));
          this.login.emit(true);
          console.log(res);
        })
      }    
  }
}