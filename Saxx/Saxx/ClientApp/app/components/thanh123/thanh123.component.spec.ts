/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Thanh123Component } from './thanh123.component';

describe('Thanh123Component', () => {
  let component: Thanh123Component;
  let fixture: ComponentFixture<Thanh123Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Thanh123Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Thanh123Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
