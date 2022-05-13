import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { Post } from "src/app/Models/post.model";
import { PostService } from "../../Services/Post/post.services";

@Component({
    selector: 'postlist-component',
    templateUrl: './postlist.component.html',
  //   styleUrls: ['./post.component.css']
  })
  export class PostListComponent implements OnInit {
    posts!: Post[];
    @Input() title!: string;
    @Input() user!: any;
    @Output() selectedPost = new EventEmitter<Post>();
    
    constructor(private postService: PostService) {
    }
    ngOnInit()
    {
      switch (this.title) {
        case "Posts":
          this.postService.getposts().subscribe(result => {
            this.posts = result;
        })
          break;
      
        case "Pending posts":
          this.postService.getpending(this.user.id).subscribe(result => {
            this.posts = result;
        })
          break;

        case "My posts":
          this.postService.getByUser(this.user.id).subscribe(result => {
            this.posts = result;
          })
          break;
      }
        
    }
    selected(post: Post)
    {
      this.selectedPost.emit(post);
    }

  }