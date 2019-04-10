import React, { Component } from 'react';

import next from '../assets/images/next.png';
import back from '../assets/images/back.png';
import './PageNaviGationTable.css';

class PageNavigationTable extends Component {
    constructor(props) {
        super(props);

        const { totalRecords } = this.props;
        console.log(totalRecords);
        this.handleChange = this.handleChange.bind(this);
        this.handleClickBack = this.handleClickBack.bind(this);
        this.handleClickNext = this.handleClickNext.bind(this);
        this.changePage = this.changePage.bind(this);
        this.state = {
            page: 1,
            numberPage: Math.ceil(totalRecords / 10),
        }
    }

    changePage() {
        const { onPageChanged = f => f } = this.props;
        this.setState(() => onPageChanged(this.state.page))
    }

    handleChange(e) {
        this.setState({ page: e.target.value })
        this.changePage();
    }

    /* componentDidMount() {
        console.log(this.props.totalRecords);
        this.setState({  });
     } */

    async handleClickBack() {
        const number = this.state.page;
        if (number > 1) {
            await this.setState({ page: number - 1 })
            this.changePage();
        }
    }

    async handleClickNext() {
        const number = this.state.page;
        if (number < this.state.numberPage) {
            await this.setState({ page: number + 1 })
            this.changePage();
        }
    }

    handlePress(e) {
        const characterCode = e.key
        if (characterCode === 'Backspace') return

        const characterNumber = Number(characterCode)
        if (characterNumber >= 0 && characterNumber <= 9) {
            if (e.currentTarget.value && e.currentTarget.value.length) {
                return
            } else if (characterNumber === 0) {
                e.preventDefault()
            }
        } else {
            e.preventDefault()
        }
    }

    render() {
        const { page } = this.state;
        return (
            (this.props.totalRecords === 0) ? null :
                <div className="form-inline">
                    <button className="pageButton" onClick={this.handleClickBack}><img className="pageImage" src={back}></img></button>
                    <input className="inputPage" max={this.state.numberPage} value={this.state.page} onChange={this.handleChange} onKeyDown={this.handlePress} ></input>
                    <p class="totalPage">of {this.state.numberPage}</p>
                    <button className="pageButton" onClick={this.handleClickNext}><img className="pageImage" src={next}></img></button>
                </div>
        );
    }
}

export default PageNavigationTable;