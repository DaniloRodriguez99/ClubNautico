import { Component, ElementRef, Input, OnInit, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-input-custom',
  templateUrl: './input-custom.component.html',
  styleUrls: ['./input-custom.component.scss']
})
export class InputCustomComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() type:string = '';
  @Input() placeholder:string = ''
  @Input() value:string = ''
  

  change = (value: string) => {
    this.value = value;
  }
}

