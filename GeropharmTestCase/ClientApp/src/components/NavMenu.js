import React, { Component, useState, useEffect, useRef } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import styles from './NavMenu.module.css';
import './NavMenu.css';
import { render } from 'react-dom';
import { CSSTransition, TransitionGroup } from 'react-transition-group'
import { Table, Head, Body, Row, Cell } from './Table/Table.js'


const getWidth = () => window.innerWidth
    || document.documentElement.clientWidth
    || document.body.clientWidth;




const Slide = ({ children, ...props }) => (
    <CSSTransition
        {...props}
        timeout={10}
        classNames="slide"
    >
        {children}
    </CSSTransition>
)

export class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);

    this.array = [['1']];

    window.onload = this.tuneRowsAndColumns;
    window.onresize = this.tuneRowsAndColumns;

    this.row = 1;
    this.column = 1;

    this.state = {
        name: 'React',
        items: this.array
    };



      
  }

  toggleNavbar () {
      this.setState({
          collapsed: !this.state.collapsed
      });
}
    
    
    
    
    

    plusOneRow = (count) => {
        const newItems = [...this.state.items];
        for (var i = 0; i < count; i++) {
            const newArray = Array.from((newItems.length + 1).toString().repeat(this.column));
            newItems.push(newArray);
            this.row += 1;
            this.setState(prevState => ({
                ...prevState,
                items: newItems
            }))
        }
        
    }

    minusOneRow = (count) => {
        const newItems = [...this.state.items];
        for (var i = 0; i < count; i++) {
            newItems.pop();
            this.row -= 1;
            this.setState(prevState => ({
                ...prevState,
                items: newItems
            }))
        }
    }

    

    plusOneColumn = () => {
        const newItems = [...this.state.items];

        for (var i = 0; i < newItems.length; i++) {
            newItems[i].push((i + 1).toString());
        }

        this.column += 1;
        this.setState(prevState => ({
            ...prevState,
            items: newItems
        }))
    }

    minusOneColumn = () => {
        const newItems = [...this.state.items];

        newItems.forEach(el => el.pop());
        this.column -= 1;

        this.setState(prevState => ({
            ...prevState,
            items: newItems
        }))
    }

    

    tuneColumns = () =>  {
        let contentWidth = document.getElementById('mainContent').clientWidth;
        let currentColumns = this.column;
        var possibleColumns = Math.floor(contentWidth / 180);
        if (possibleColumns > currentColumns) {
            var countOfPlusColumns = possibleColumns - currentColumns;
            for (var i = 0; i < countOfPlusColumns; i += 1) {
                this.plusOneColumn();
            }
        }
        else {
            var countOfMinusColumns = currentColumns - possibleColumns;
            for (var i = 0; i < countOfMinusColumns; i += 1) {
                this.minusOneColumn();
            }
        }

    }

    tuneRows = () => {

        let contentHeight = document.getElementById('mainContent').clientHeight;
        let currentRows = this.row;
        var possibleRows = Math.floor(contentHeight / 130);
        if (possibleRows > currentRows) {
            var countOfPlusRows = possibleRows - currentRows;

            this.plusOneRow(countOfPlusRows);
            
        }
        else {
            var countOfMinusRows = currentRows - possibleRows;
            this.minusOneRow(countOfMinusRows);
            
        }
    }

    tuneRowsAndColumns = () => {
        this.tuneColumns();
        this.tuneRows();
        
    }

    
    render() {
        return (
            <>
                
                <div className={styles.header}>
                    <h3 className={styles.header}>Header</h3>
                    
                </div>

                <div>
                    <h2 className={styles.leftSide}>Left side</h2>
                </div>

                <div className={styles.mainContent} id = "mainContent">
                    <div slassName={styles.table}>
                        <Table>
                            <Body>
                                <TransitionGroup>
                                    {this.state.items.map(item => (
                                        <Slide key={item[1]}>
                                            <Row>
                                                {item.map(prop => (
                                                    <Cell>
                                                        <button className={styles.button}>
                                                            {prop}
                                                        </button>
                                                    </Cell>
                                                ))}
                                            </Row>
                                        </Slide>
                                    ))}
                                </TransitionGroup>
                            </Body>
                        </Table>
                    </div>
                    

                    
                </div>

                

                <div>
                    <h2 className={styles.rightSide}>Right side</h2>
                </div>

                <div className={styles.footerDiv}>
                    <h2 className={styles.footer}>Footer</h2>
                </div>


            </>
            
                
      );
  }
}
