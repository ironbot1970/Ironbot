import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RobotService } from 'src/app/services/robot.service';
import { Robot } from 'src/app/shared/models/Robot';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  robots: Robot[] = [];

  constructor(private robotService: RobotService, activatedRoute: ActivatedRoute) {
    activatedRoute.params.subscribe((params) => {
      if (params.searchTerm)
        this.robots = this.robotService.getAllRobotsBySearchTerm(params.searchTerm);
      else if (params.tag)
        this.robots = this.robotService.getAllRobotsByTag(params.tag);
      else
        this.robots = robotService.getAll();
    });
  }

  onSortChange(event: Event): void {
    const value = (event.target as HTMLSelectElement)?.value;
    if (value) {
      const sortOrder: 'asc' | 'desc' = value as 'asc' | 'desc';
      this.robots = this.robotService.getAllRobotsByPrice(sortOrder === 'asc');
    }
  }

  ngOnInit(): void { 
  }
}
