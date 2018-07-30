import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DungComponent } from './dung.component';

describe('DungComponent', () => {
  let component: DungComponent;
  let fixture: ComponentFixture<DungComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DungComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DungComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
