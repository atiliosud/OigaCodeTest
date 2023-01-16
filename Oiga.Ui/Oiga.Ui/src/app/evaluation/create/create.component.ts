import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Course } from 'src/app/course/course';
import { CourseService } from 'src/app/course/courses.service';
import { EvaluationService } from '../evaluation.service';
import { Student } from '../students';
import { StudentService } from '../students.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  
  evaluationForm!: FormGroup;
  students: Student[];
  courses: Course[];
  errors: any[] = [];

  constructor(
    private fb: FormBuilder,
    public evaluationService: EvaluationService,
    public studentService: StudentService,
    public courseService: CourseService,
    private router: Router
  ) {
    this.studentService.getStudents()
      .subscribe(
        students => this.students = students,
        fail => this.errors = fail.error.errors
      );

    this.courseService.getCourse()
      .subscribe(
        courses => this.courses = courses,
        fail => this.errors = fail.error.errors
      );

  }

  ngOnInit(): void {
    this.evaluationForm = this.fb.group({
      courseId: '',
      studentId: '',
      description: '',
      stars: '0'
    });
  }

  submit(){
    console.log(this.evaluationForm.value);
    this.evaluationService.create(this.evaluationForm.value).subscribe((res:any) => {
         console.log('Evaluation created successfully!');
         this.router.navigateByUrl('course');
    })
  }

  changeCourse(event: any){
    this.studentService.getStudentsCourse(event.target.value)
      .subscribe(
        students => this.students = students,
        fail => this.errors = fail.error.errors
      );

  }

}
