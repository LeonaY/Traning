
var TodoActions = Reflux.createActions([
    'getAll'
]);

var TodoStore = Reflux.createStore({
    items: [1,2,3],
    listenables: [TodoActions],
    onGetAll: function (like) {
        this.trigger({ name: 'lin', age: 30 });
        
    }
});

var TodoComponent = React.createClass({
    mixins: [Reflux.connect(TodoStore, 'like')],
    getInitialState: function () {
        return { like: {name : 'yan', age : 23}};
    },
    componentDidMount: function () {
        TodoActions.getAll();
    },
    handleShowTxt: function () {
        TodoActions.getAll(this.state.like);
    },
    render: function () {
        const showTxt = this.state.like ? 'like' : 'hate';
        return (
            <div className="title" onClick={this.handleShowTxt}>
                please click me, i {showTxt} you
            </div>
        )
    }
});

var TodoComponent2 = React.createClass({
    mixins: [Reflux.connect(TodoStore, 'like')],
    getInitialState: function () {
        return { like: { name: '', age: 0 }};
    },
    //componentWillUpdate: function () {
    //    //console.log(this.state.like);
    //    //return true;
    //},    
    handleShowTxt: function () {
    },
    render: function () {
        const showTxt = this.state.like ? 'like' : 'hate';
        return (
            <div className="title2" onClick={this.handleShowTxt}>
               lalala, i {showTxt} you
            </div>
        )
    }
});
//React.render(<TodoComponent />, document.getElementById('container'));