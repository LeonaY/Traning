
var DnDActions = Reflux.createActions([
    'addHobby',
    'removeHobby'
]);

var DnDStore = Reflux.createStore({
    listenables: [DnDActions],      
    _state: {
        action: '',
        hobbyItem: ''
    },
    getInitialState () {
        return {
            action: '',
            hobbyItem: ''
        }
    },
    onAddHobby: function (content) {
        console.log('AddHobby');
        this._state.action = 'Add';
        this._state.hobbyItem = content;
        this.trigger(this._state);

    },   
    onRemoveHobby: function (content) {
        console.log('onRemoveHobby');
        this._state.action = 'Remove';
        this._state.hobbyItem = content;
        this.trigger(this._state);

    }
});


var HobbyItem = React.createClass({
    getDefaultProps: function () {
        return {
        };
    },
    getInitialState: function () {
        return {
            hobbyList: ['swimming', 'running', 'basketball']
        };
    },
    DragStart(e) {
        DnDActions.addHobby(e.currentTarget.textContent);
    },
    onDrop() {
        this.setState({ DragStart: !this.state.DragStart });
        console.log('onDrop');
    },
    render: function () {
        return <div onDragStart={this.DragStart} draggable='true'  onDrop={this.onDrop }>{this.props.hobby}</div>;
    }
});

var HobbyDIV = React.createClass({    
    mixins: [Reflux.connect(DnDStore)],
    getInitialState: function () {
        return {
            hobbyList: ['swimming', 'running', 'basketball']
        };
    },
    onTestClick(e) {
        console.log("ontestClick");
    },
    componentDidUpdate(){     
        console.log('componentDidUpdate :' + this.state.action);
        if(this.state.action == "Remove")
        {
            var index = this.state.hobbyList.indexOf(this.state.hobbyItem);
            this.state.hobbyList.splice(index, 1)
            this.setState({hobbyList : this.state.hobbyList});
            console.log('DeleteItem :' + this.state.action);
            this.state.action = '';
        }
    },
    render: function () {
        return (
          <div className="DIVBorder" key="DIVBorder">
            
              <div onClick={this.onTestClick}>test</div>
                  {
                  this.state.hobbyList.map(function (num) {
                  return <HobbyItem hobby={num} key={num } />;
                  })
                  }
              </div>

        );
    }
});


var UserDIV = React.createClass({
    mixins: [Reflux.connect(DnDStore)],
    getDefaultProps: function() {
        return {
            autoPlay: false,
            maxLoops: 10,
        };
    },
    getInitialState: function() {
        return {
            UserHobbyList: []
        };
    },
    DrageDIV() {
        console.log('DrageDIV');
    },
    onUserDrop(e) {
        this.setState({UserHobbyList : React.addons.update(this.state.UserHobbyList, { $push: [this.state.hobbyItem] })});
        DnDActions.removeHobby(this.state.hobbyItem);
        console.log('onUserDrop!!!');
        
    },
    onUserDragOver(e){
        e.preventDefault();
    },
    componentWillMount()
    {
        console.log('UserDIVcomponentWillMount');
    },
    componentWillUpdate(){     
        console.log('componentWillUpdate');
    },
    render() {
        var result;
        if (this.state.UserHobbyList != 'undefined')
        {
            result = this.state.UserHobbyList.map(function (num) {
                return(
                        <div key={num} className="User">
                            {num}
                        </div>);
                      })
        }
              
        return (
          <div className="UserIDVT DIVBorder" key="UserIDV"  draggable='true' onDragStart={this.DrageDIV} onDragOver={this.onUserDragOver} onDrop={this.onUserDrop}>
              {result}              
          </div>
);
}
})
//ReactDOM.render(
//  <HobbyDIV  />,
//  document.getElementById('content')
//);

          //<div className="UserDIV DIVBorder" draggable='true' onDragStart={this.DrageDIV} onDragOver={this.onUserDragOver} onDrop={this.onUserDrop}>
          //    333
          //</div>