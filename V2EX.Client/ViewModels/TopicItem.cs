﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Prism.Mvvm;
using V2EX.Client.Utils;
using V2EX.Client.ViewModels.Links;

namespace V2EX.Client.ViewModels
{
    public class TopicItem : BindableBase
    {
        private TextLink _title;
        private TextLink _node;
        private TextLink _author;
        private TextLink _lastReplyMember;
        private string _lastReplyTime;
        private TextLink _repliesCount;
        private ImageLink _avatar;

        public TextLink Title
        {
            get => _title;
            set => SetProperty(ref _title , value);
        }

        public TextLink Node
        {
            get => _node;
            set => SetProperty(ref _node, value);
        }

        public TextLink Author
        {
            get => _author;
            set => SetProperty(ref _author, value);
        }

        public TextLink LastReplyMember
        {
            get => _lastReplyMember;
            set => SetProperty(ref _lastReplyMember, value);
        }

        public string LastReplyTime
        {
            get => _lastReplyTime;
            set => SetProperty(ref _lastReplyTime, value);
        }

        public TextLink RepliesCount
        {
            get => _repliesCount;
            set => SetProperty(ref _repliesCount, value);
        }

        public ImageLink Avatar
        {
            get => _avatar;
            set => SetProperty(ref _avatar, value);
        }
        
        public TopicItem()
        {

        }
    }
}
