import React, { Component } from 'react';
import ReactDOM from 'react-dom';

class FileUploadApp extends Component {
    constructor(props) {
        super(props);

        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(evt) {

        evt.preventDefault();
        var formData = new FormData(evt.target);

        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "multipart/form-data");

        debugger;

        fetch('http://localhost:53929/file', {
            method: 'post',
            body: formData,
            // headers: myHeaders
        }).then(r => {
            debugger;
        }, rejection => {
            debugger;
        })

        return false;
    }

    render() {
        return (<React.Fragment>
            <form onSubmit={this.handleSubmit} method="post">
                <input name="arquivo" type="file"></input>
                <button type="submit">Go</button>
            </form>
        </React.Fragment>);
    }

}

ReactDOM.render(<FileUploadApp />, document.getElementById('root'));