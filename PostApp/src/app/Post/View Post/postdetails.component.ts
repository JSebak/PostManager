import { Component, EventEmitter, Input, Output } from '@angular/core';
import {  FormControl, FormGroup, Validators } from '@angular/forms';
import { Guid } from 'guid-typescript';
import { CommentModel } from 'src/app/Models/comment.model';
import { Post } from 'src/app/Models/post.model';
import { CommentService } from 'src/app/Services/Comment/comment.service';
import { PostService } from 'src/app/Services/Post/post.services';

@Component({
  selector: 'postdetails-component',
  templateUrl: './postdetails.component.html',
  styleUrls: ['./postdetails.component.css']
})
export class PostDetailsComponent {
  @Input() public post!: Post ;
  @Input() public user!: any;
  @Output() modify = new EventEmitter<boolean>();
  @Output() deleted = new EventEmitter<boolean>();
  comments: CommentModel[] =[];
  commentForm!: FormGroup;
  status!: string

    constructor(private commentService: CommentService, private postService: PostService) {
    }
  ngOnInit(){
    let status = this.post.status == null ? "": String(this.post.status)
    switch (status) {
      case "true":
        this.status = "Approved"
        break;
      case "false":
        this.status = "Rejected"
        break;
      default:
        this.status = "Pending"
        break;
    }
    if(this.post != null){
        this.commentService.getbypost(this.post.id).subscribe(result =>
            {
                this.comments = result;
            })
      }
    this.commentForm = new FormGroup({
        content: new FormControl('', [Validators.required, Validators.minLength(1), Validators.maxLength(150)])
    })
  }
  onSubmit(){
    let comment = new CommentModel();
    let content = this.commentForm.controls["content"].value
    comment.id = Guid.create().toString();
    comment.postId = this.post.id;
    comment.authorId = this.user == "guest" ? null : this.user?.id
    comment.content = content
    this.commentService.add(comment).subscribe(result=>
        {
            console.log(result)
            this.comments.push(comment);
        })
        
  }
  edit(){
    this.modify.emit(true);
  }
  deleteComment(commentId: string)
  {
      this.commentService.delete(commentId).subscribe(result =>
        {
            console.log(result)
            this.comments = this.comments.filter(c=>c.id != commentId);
        })
  }
  deletePost()
  {
    this.postService.delete(this.post.id).subscribe(result =>{
      console.log(result);
      this.deleted.emit(true);
    })
  }
  reviewPost(status: boolean){
    let newStatus = String(status)
    this.postService.review(this.post.id,newStatus).subscribe(result =>
      {
        this.post.status = newStatus;
        console.log(result);
      })
  }
}
