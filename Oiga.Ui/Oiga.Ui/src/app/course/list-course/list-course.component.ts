import { Component, OnInit } from '@angular/core';
import { Course } from '../course';
import { CourseService } from '../courses.service';

@Component({
  selector: 'app-list-course',
  templateUrl: './list-course.component.html',
  styleUrls: ['./list-course.component.css']
})
export class ListCourseComponent implements OnInit{
  constructor(private courseService: CourseService) { }

  public courses: Course[];
  public imageURL: string;
  errorMessage: string;

  ngOnInit() {
    this.courseService.getCourse()
      .subscribe(
        courses => this.courses = courses,
        error => this.errorMessage = error,
    );   
  }
}
