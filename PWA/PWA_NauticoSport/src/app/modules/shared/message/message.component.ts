import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss']
})
export class MessageComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input()
  message: string = ""

  @Input()
  type: string = MESSAGES_TYPES.normal
  
  
}

const MESSAGES_TYPES = {
    error: "error",
    sucess: "sucess",
    normal: "normal"
}
