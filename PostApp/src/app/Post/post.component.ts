import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Post } from '../Models/post.model';

@Component({
  selector: 'post-component',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent {
  @Input() public post: any ;
  @Output() selected = new EventEmitter<Post>();

  

  ngOnInit(){

  }
  Open(post: any){
    this.selected.emit(post);
  }

}
